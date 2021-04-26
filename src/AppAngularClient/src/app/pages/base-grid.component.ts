
import { Router } from '@angular/router';
import { OnInit, ViewChild, AfterViewInit, Input, OnDestroy, Directive } from '@angular/core';

import 'devextreme/integration/jquery';
import { DxDataGridComponent } from 'devextreme-angular';
import { BaseService } from './services/base.service';
import { IBaseModel } from './models/IBase-model';


@Directive()
export abstract class BaseGridComponent<
    TService extends BaseService<IBaseModel>,
    TModel extends IBaseModel
    > implements OnInit, OnInit, AfterViewInit, OnDestroy, AfterViewInit {

    @ViewChild(DxDataGridComponent)
    grid: DxDataGridComponent;
    @ViewChild('grid', { static: false })
    grid2: DxDataGridComponent;
    @ViewChild('grid')
    grid3: DxDataGridComponent;

    events: Array<string> = [];
    public nome_tela = '';

    protected routeBase: string;

    //#region Variaveis da Grid
    @Input() _enableGridAdding = false;
    @Input() _enableGridEditing = false;
    @Input() _enableGridDeleting = false;
    public allowColumnResizing = false;
    public columnResizingMode = 'widget';
    @Input() noDataText = 'Sem Registros para esta Tela';
    @Input() editingMode = 'form';
    @Input() showSelection: boolean;

    //#endregion

    //#region doubleClick
    public clickTimer;
    public lastRowCLickedId;
    public isDoubleClick = false;
    public isSingleClick = false;
    //#endregion

    @Input() isChildrenForm: boolean;
    @Input() IamPopUp: any = true;
    @Input() formPai: any = null;
    @Input() filtroSexo: string;

    public dataSource: any = {};

    constructor(
        protected router: Router,
        protected service: TService,
        protected isSetDataSource?: boolean
    ) {
      // this.fillDataSource();
     }

     fillDataSource() {
      this.isSetDataSource = this.isSetDataSource === undefined || this.isSetDataSource == null ? true : this.isSetDataSource;
      if (this.isSetDataSource) {
        this.dataSource = this.service.dataSource;
      }
     }
     ngOnInit() {

    }


    configurarGrid() {
        const that = this;

        if (this.grid) {
            this.grid.filterRow = { visible: true };
            this.grid.headerFilter = { visible: true };
            this.grid.searchPanel = { visible: true };
            this.grid.paging = { pageSize: 10 };
            if (this.allowColumnResizing === true) {
                this.grid.allowColumnResizing = this.allowColumnResizing;
                this.grid.columnResizingMode = this.columnResizingMode;
                this.grid.columnMinWidth = 80;
            }
            this.grid.editing = {
                allowDeleting: this._enableGridDeleting,
                allowUpdating: this._enableGridEditing,
                allowAdding: this._enableGridAdding,
                mode: this.editingMode,
            };

            if (this.showSelection === true) {
                this.grid.selection = {
                    mode: 'multiple',
                };
            }
            this.grid.noDataText = this.noDataText;

            this.grid.onRowClick.subscribe(this.onRowClick);
            this.grid.onCellPrepared.subscribe(this.onCellPrepared);
            this.grid.onSelectionChanged.subscribe(this.onSelectionChanged);
            this.grid.onEditorPreparing.subscribe(this.onEditorPreparing);
            this.grid.onRowInserting.subscribe(this.onRowInserting);
            this.grid.onRowInserted.subscribe(this.onRowInserted);
            this.grid.onRowUpdating.subscribe(this.onRowUpdating);
            this.grid.onRowUpdated.subscribe(this.onRowUpdated);
            this.grid.onToolbarPreparing.subscribe(this.onToolbarPreparing);
        }
    }
    public setGridEnableAdding(value: boolean) {
        this._enableGridAdding = value;
    }
    public setGridEnabledEditing(value: boolean) {
        this._enableGridEditing = value;
    }
    public setGridEnableDeleting(value: boolean) {
        this._enableGridDeleting = value;
    }
    public setGridTextNoData(value: string) {
        this.noDataText = value;
    }
    public setChildrenForm(value: boolean) {
        this.isChildrenForm = value;
    }

    onRowClick = (e) => {
        if (this.clickTimer && this.lastRowCLickedId === e.rowIndex) {
            clearTimeout(this.clickTimer);
            this.clickTimer = null;
            this.lastRowCLickedId = e.rowIndex;
            this.isDoubleClick = true;
        } else {
            this.clickTimer = setTimeout(() => {}, 250);
            this.isSingleClick = true;
        }

        this.lastRowCLickedId = e.rowIndex;
    }
    onEditorPreparing = (e) => {
    }
    onRowInserting = (e) => {}
    onRowInserted = (e) => {}
    onContentReady = (e) => {}
    onRowUpdating = (e) => {}
    onRowUpdated = (e) => {}

    onCellPrepared = (e) => {
    }
    onToolbarPreparing = (e, fn) => {
        e.toolbarOptions.items.unshift({
            location: 'after',
            widget: 'dxButton',
            name: 'refreshGridButton',
            options: {
                icon: 'refresh',
                onClick: this.refresh.bind(this),
            }
        });
    }

    ngOnDestroy() {
    }

    ngAfterViewInit() {
        this.configurarGrid();

    }
    onSelectionChanged = (e) => {
    }
    refresh() {
      this.grid.instance.refresh();
  }
}
