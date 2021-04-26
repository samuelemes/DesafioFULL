export class MasksService {
    public static masks: any = {
      date: { format: '00/00/0000' },
      cep: { format: '00000-000' },
      cnpj: { format: 'XX.XXX.XXX/XXXX-XX', rules: { X: /[0-9]?/ } },
      cpf: { format: '000.000.000-00' },
      phone: { format: '(00) 0000-0000X', rules: { X: /[0-9]?/ } }
    };
  }
  