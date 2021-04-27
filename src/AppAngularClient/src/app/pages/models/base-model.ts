import { IBaseModel } from './IBase-model';
export abstract class BaseModel implements IBaseModel {
    public Id: number;

    constructor(model?: any) {
      if (model != null || model !== undefined) {
        this.copyFrom(model);
      }
    }

    public getId(): number {
      return this.Id;
    }

    copyFrom(o: any): any {
      // tslint:disable-next-line:forin tslint:disable-next-line:prefer-const
      for (const key in o) {
        this[key] = o[key];
      }
      return this;
    }
  }
