import { Component } from '@angular/core';
import { Router } from '@angular/router';
import 'devextreme/data/odata/store';
import { DocumentoModel } from '../models/titulo-model';
import { DocumentoService } from '../services/documento.service';
import { MasksService } from '../services/maskService';
import { BaseGridComponent } from '../base-grid.component';

@Component({
  templateUrl: 'faturas.component.html'
})

export class FaturasComponent extends BaseGridComponent<DocumentoService, DocumentoModel>{
  dataSource: any;
  tipoDocumentoDataSource: any;
  priority: any[];

  IamPopUp = true;
  editingMode = 'popup'
  public cpfMask = MasksService.masks.cpf;
  cpfValidado = true;

  constructor(
    router: Router,
    protected service: DocumentoService
  ) {
    super(router, service);
    this.service.getFaturas().subscribe(res => this.dataSource = res);

    this.tipoDocumentoDataSource = [
      {id: 1, value: 'Fatura'},
      {id: 2, value: 'Titulo'},
    ];
  }
}
