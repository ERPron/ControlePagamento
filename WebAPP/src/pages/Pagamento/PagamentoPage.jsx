import { useEffect, useState, useRef } from "react"
import Header from "../../componets/header/Header";
import Trash from '../../assets/react.svg'
import Editar from '../../assets/editar.png'
import Api from "../../services/api"
import './PagamentoPage.css'

export default function PagamentoPage() {
    const inputRef = useRef(null)
    const [Pagamento, setPagamentos] = useState([])

    const inputId = useRef()
    const inputIdCliente = useRef()
    const inputValor = useRef()
    const inputData = useRef()
    const inputStatus = useRef()

    async function getPagamentoByIdClientes(idcliente) {
        const pagamentoFromApi = await Api.get(`/api/Pagamentos/GetByClienteIdAsync?clienteId=${idcliente}`)
        setPagamentos(pagamentoFromApi.data)
    }

    const handleClick = () => {
        const inputId = inputRef.current.value; // Acessando o id diretamente da ref
        getPagamentoByIdClientes(inputId);
        inputRef.current.value = '';
    };

    async function createPagamento() {
        await Api.post('/api/Pagamentos/AddAsync', {
            Id: inputId.current.value ?? 0,
            ClienteId: inputIdCliente.current.value,
            Data: inputData.current.value,
            Valor: inputValor.current.value,
            Status: inputStatus.current.value
        })
    }

    useEffect(() => { getPagamentoByIdClientes(1) }, [])

    return (
        <div>
            <Header />
            <div class="container">
                <form>
                    <h1>Cadastro de Pagamento</h1>
                    <input placeholder="Id" name="id" type='text' ref={inputId} ></input>
                    <input placeholder="Id Cliente" name="idcliente" type='text' ref={inputIdCliente} ></input>
                    <input placeholder="Data" name="data" type='text' ref={inputData} ></input>
                    <input placeholder="Valor R$" name="valor" type='text' ref={inputValor}></input>
                    <input placeholder="Status" name="status" type='text' ref={inputStatus}></input>
                    <button type='button' onClick={createPagamento}>Cadastrar</button>
                </form>

                <div class="cardc">
                    <input placeholder="Digite o Id" name="idConsulta" type='text' ref={inputRef}></input>
                    <button type='button' onClick={handleClick}>Consultar</button>
                </div>

                {Pagamento.map(pag => (
                    <div key={pag.id} className="cardl">
                        <div>
                            <p>Id: {pag.id}</p>
                            <p>Id Cliente: {pag.clienteId}</p>
                            <p>Data: {pag.data}</p>
                            <p>Valor R$: {pag.valor}</p>
                            <p>Status: {
                                String(pag.status) === '0' ? 'Pendente' :
                                String(pag.status) === '1' ? 'Pago' : 'Cancelado'}</p>
                        </div>
                        <div>
                            <button><img src={Editar} /></button>
                        </div>
                    </div>
                ))}

            </div>
        </div>
    )
}