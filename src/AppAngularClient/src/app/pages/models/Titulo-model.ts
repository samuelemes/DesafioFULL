import { BaseModel } from "./base-model";
import { PessoaModel } from "./PessoaModel";
import { TipoDocumentoModel } from "./TIpoDocumentoModel";


export class DocumentoModel extends BaseModel {

        public idDocumentoOrigem: number;
        public TipoDocumentoModel: TipoDocumentoModel = new TipoDocumentoModel();
        public DocumentoOrigem: DocumentoModel[];
        public Pessoa: PessoaModel = new PessoaModel();
        public DataVencimento: number;
        public DataPagamento;
        public Juros: number;
        public Multa: number;
        public Parcela: number;
        public QtdeParcelas: number;
        public Valor: number;
        public ValorOriginal: number;
        public ValorPago: number;
        public ValorDesconto: number;
        public ValorAtualizado: number
        public DiasEmAtrado: number
  }
