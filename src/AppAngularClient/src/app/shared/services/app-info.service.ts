import { Injectable } from '@angular/core';

@Injectable()
export class AppInfoService {
  constructor() {}

  public get title() {
    return 'CADASTRO DE TÍTULOS EM ATRASO';
  }

  public get currentYear() {
    return new Date().getFullYear();
  }
}
