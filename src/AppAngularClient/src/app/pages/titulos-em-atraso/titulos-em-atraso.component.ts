import { Component } from '@angular/core';
import { Router } from '@angular/router';
import 'devextreme/data/odata/store';
import { DocumentoModel } from '../models/titulo-model';
import { DocumentoService } from '../services/documento.service';
import { MasksService } from '../services/maskService';
import { BaseGridComponent } from '../base-grid.component';

@Component({
  templateUrl: 'titulos-em-atraso.component.html'
})

export class TitulosEmAtrasoComponent extends BaseGridComponent<DocumentoService, DocumentoModel>{
  // dataSource: any;
  tipoDocumentoDataSource: any;
  priority: any[];

  IamPopUp = true;
  editingMode = 'popup'
  _enableGridAdding = true;
  public cpfMask = MasksService.masks.cpf;
  cpfValidado = false;
  model: DocumentoModel = new DocumentoModel();

  constructor(
    router: Router,
    protected service: DocumentoService
  ) {
    super(router, service);

    this.tipoDocumentoDataSource = [
      {id: 1, value: 'Fatura'},
      {id: 2, value: 'Titulo'},
    ];

    const that = this;
    this.dataSource = this.service.createDataSource({
      insert: value => {
        return new Promise(function(resolve, reject) {
          return that.service.saveDocument(that.model);
        });
      },
    });
  }
}
