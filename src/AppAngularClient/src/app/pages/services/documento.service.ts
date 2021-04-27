import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { BaseService } from './base.service';
import { DocumentoModel } from '../models/titulo-model';
import { Observable } from 'rxjs/internal/Observable';


@Injectable()
export class DocumentoService extends BaseService<DocumentoModel> {

    constructor(
        protected http: HttpClient,
    ) {
      super(http, 'Titulos');
    }

    public get(): Observable<DocumentoModel[]> {
      this.url += '/Titulos';
      return this.https.get<DocumentoModel[]>(this._httpAdress + 'Titulos/GetTituloVencidos', { headers: this._headers }).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }


    public getFaturas(): Observable<DocumentoModel[]> {
      return this.https.get<DocumentoModel[]>(this._httpAdress + 'Titulos/GetFaturas', { headers: this._headers }).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }

    public getTituloAVencer(): Observable<DocumentoModel[]> {
      return this.https.get<DocumentoModel[]>(this._httpAdress + 'Titulos/GetDocumentosAVencer', { headers: this._headers }).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }

    public create(model: any): Observable<DocumentoModel> {
      this.url = 'Titulos/Post';
      return super.create(model);
    }
}
