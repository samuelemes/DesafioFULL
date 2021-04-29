import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from "rxjs";
import { IBaseModel } from "../models/IBase-model";
import { IBaseServiceInterface } from "./base.service-interface";
import * as $ from 'jquery';

export abstract class BaseService<T extends IBaseModel>
    implements IBaseServiceInterface<T> {

    public dataSource: any = {};
    public _httpAdress = 'http://localhost:9000/';
    keyName = 'Id';
    public model: T;
    protected _headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    constructor(
      protected https: HttpClient,
      protected url: string
    ) {
        this.createDataSource();
    }

    get baseUrl(): string {
      return this.url;
    }

    set baseUrl(value) {
      this.url = value;
    }

    public get(): Observable<T[]> {
      return this.https.get<T[]>(this._httpAdress + this.url, { headers: this._headers }).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }
    public getOne(id: any): Observable<T> {
      return this.https.get<T>(`${this._httpAdress + this.url}/${id}`).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }

    getNew(model?: any): T {
      throw new Error('Method not implemented.');
    }

    public save(model: T, id: any): Observable<T> {
      return id != null ? this.update(model, id) : this.create(model);
    }
    public create(model: T): Observable<T> {
      const args = {
        headers: this._headers
      };

      return this.https.post<T>(`${this._httpAdress + this.url}`, JSON.stringify(model), args).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }

    public update(model: T, id: any): Observable<T> {
      return this.https
        .put<T>(`${this._httpAdress + this.url}/${id}`, JSON.stringify(model))
        .pipe(
          map(data => data),
          catchError(error => {
            return throwError(error);
          })
        );
    }

    public delete(id: any): Observable<T> {
      return this.https.delete<T>(`${this._httpAdress + this.url}/${id}`).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }

    public getDataSource(): any {
      this.createDataSource();
      return this.dataSource;
    }

    public prepareModel(model: any) {
      return model;
    }

    public createDataSource(ds?: any) {
      const that = this;
      this.dataSource = $.extend(
        {
          key: that.keyName,
          load: loadOptions => {
            return new Promise(function(resolve, reject) {
              if (loadOptions && loadOptions.searchValue) {
                return that
                  .search(loadOptions.searchValue, loadOptions.searchOperation)
                  .subscribe(
                    (response: any) => {
                      resolve(response || []);
                    },
                    error => {
                      resolve([]);
                      // this.success = false;
                    }
                  );
              }
              return that.get().subscribe(
                (response: any) => {
                  resolve(response || []);
                },
                error => {
                  resolve([]);
                  // this.success = false;
                }
              );
            });
          },
          byKey: (key, extra) => {
            return new Promise(function(resolve, reject) {
              return that.getOne(key).subscribe(
                (response: any) => {
                  resolve(response);
                },
                error => {
                  reject();
                  // this.success = false;
                }
              );
            });
          },
          insert: values => {
            return new Promise(function(resolve, reject) {
              return that.save(that.prepareModel(values), null).subscribe(
                (response: any) => {
                  resolve(response);
                },
                error => {
                  resolve({});
                  // this.success = false;
                }
              );
            });
          },
          update: (key, values) => {
            return new Promise(function(resolve, reject) {
              return that.save(that.prepareModel(values), key).subscribe(
                (response: any) => {
                  resolve(response);
                },
                error => {
                  reject();
                  // this.success = false;
                }
              );
            });
          },
          remove: key => {
            return new Promise(function(resolve, reject) {
              return that.delete(key).subscribe(
                (response: any) => {
                  resolve(response);
                },
                error => {
                  reject();
                }
              );
            });
          }
        },
        ds
      );

      return this.dataSource;
    }

    public factory<T>(a: { new (): T }) {
      return new a();
    }

    public search(term?: string, mode: string = 'contains'): Observable<T[]> {
      const args = {
        params: this.httpParamsFactory({ search: term || '', mode: mode }),
        headers: this._headers
      };
      return this.https.get<T[]>(this._httpAdress, args);
    }

    public httpParamsFactory(params: any): HttpParams {
      const httpParams = new HttpParams();
      for (const key in params) {
        if (params.hasOwnProperty(key)) {
          httpParams.set(key, params[key]);
        }
      }
      return httpParams;
    }

    protected handleError(error: HttpErrorResponse) {
      const that = this;
      try {
        if (error.status === 401) {
          // that.identityService.logout();
          return;
        } else if (error.status === 0) {
        } else {
        }
      } catch (exC) {
      }
    }
}
