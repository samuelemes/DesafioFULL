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
      super(http, 'Documentos');
    }



    public getFaturas(): Observable<DocumentoModel[]> {
      return this.https.get<DocumentoModel[]>(this._httpAdress + this.url + '/GetFaturas', { headers: this._headers }).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }

    public getTituloAVencer(): Observable<DocumentoModel[]> {
      return this.https.get<DocumentoModel[]>(this._httpAdress + this.url + '/GetDocumentosAVencer', { headers: this._headers }).pipe(
        map(data => data),
        catchError(error => {
          return throwError(error);
        })
      );
    }

    public saveDocument(model: DocumentoModel) {
      this.url += '/CreateDocument';
      console.log(this.url);
      this.create(model);
    }

    getNew(model?: any): DocumentoModel {
      let instance = this.factory<DocumentoModel>(model);

      if (model)
        instance.copyFrom(model);

      return instance;
    }
}
