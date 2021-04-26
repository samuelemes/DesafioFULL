import { IBaseModel } from '../models/IBase-model';

export interface IBaseServiceInterface<T extends IBaseModel> {

    dataSource: any;

    get();
    getOne(id: any);
    getNew(model?: any): T;
    save(model: T, id: any);
    create(model: T);
    update(model: T, id: any);
    delete(id: any);
}
