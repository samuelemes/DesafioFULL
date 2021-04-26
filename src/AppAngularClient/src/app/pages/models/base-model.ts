import { IBaseModel } from './IBase-model';
export abstract class BaseModel implements IBaseModel {
    public id: number;

    cod_usuario_inclusao: number;
    dat_inclusao: Date;
    cod_usuario_alteracao?: number;
    dat_alteracao: Date;

    constructor(model?: any) {
      if (model != null || model !== undefined) {
        this.copyFrom(model);
      }
    }

    public getId(): number {
      return this.id;
    }

    copyFrom(o: any): any {
      // tslint:disable-next-line:forin tslint:disable-next-line:prefer-const
      for (const key in o) {
        this[key] = o[key];
      }
      return this;
    }
  }
