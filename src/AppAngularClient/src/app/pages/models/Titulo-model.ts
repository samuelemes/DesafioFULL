import { BaseModel } from "./base-model";
import { PessoaModel } from "./PessoaModel";
import { TipoDocumentoModel } from "./TIpoDocumentoModel";


export class DocumentoModel extends BaseModel {

        public idDocumentoOrigem?: number;
        public TipoDocumento: TipoDocumentoModel;
        public DocumentoOrigem: DocumentoModel = new DocumentoModel();
        public Pessoa: PessoaModel;
        public DataVencimento: Date;
        public DataPagamento?: Date;
        public Juros?: number;
        public Multa?: number;
        public Parcela: number;
        public QtdeParcelas: number;
        public Valor: number;
        public ValorOriginal: number;
        public ValorPago: number;
        public ValorDesconto: number;
        public ValorAtualizado: number
        public DiasEmAtrado: number
  }
