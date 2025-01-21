import { useEffect, useState, useRef } from "react"
import Header from "../../componets/header/Header"
import Api from "../../services/api"
import Trash from '../../assets/react.svg'
import './ClientePage.css'

export default function ClientePage() {
    const inputRef = useRef(null)
    const [clientes, setClientes] = useState([])

    const inputId = useRef()
    const inputNome = useRef()
    const inputEmail = useRef()

    async function getAllClientes() {
        const clientesFromApi = await Api.get('/api/Clientes/GetAll')
        setClientes(clientesFromApi.data)
    }

    async function getByIdClientes(id) {
        const clientesByFromApi = await Api.get(`/api/Clientes/GetById?id=${id}`)
        setClientes(clientesByFromApi.data)
    }

    async function createClientes() {
        await Api.post('api/Clientes/Create', {
            Id: inputId.current.value ?? 0,
            Nome: inputNome.current.value,
            Email: inputEmail.current.value
        })   

        getAllClientes()
    }

    const handleClick = () => {
        const inputIdc = inputRef.current.value;
        getByIdClientes(inputIdc);
        inputRef.current.value = '';
    };

    useEffect(() => { getAllClientes() }, [])

    return (
        <>
            <Header />
            <div className="container">
                <form>
                    <h1>Cadastro de Cliente</h1>
                    <input placeholder="Id Cliente" name="id" type='text' ref={inputId}></input>
                    <input placeholder="Nome Cliente" name="nome" type='text' ref={inputNome}></input>
                    <input placeholder="E-mail Cliente" name="email" type='text' ref={inputEmail}></input>
                    <button type='button' onClick={createClientes}>Cadastrar</button>
                </form>

                <div class="cardc">
                    <input placeholder="Digite o Id" name="idConsulta" type='text' ref={inputRef}></input>
                    <button type='button' onClick={handleClick}>Consultar</button>
                </div>

                {(Array.isArray(clientes) ? clientes : [clientes]).map(cli => (
                    <div key={cli.id} className="cardl">
                        <div>
                            <p>Id: {cli.id}</p>
                            <p>Nome: {cli.nome}</p>
                            <p>Email: {cli.email}</p>
                        </div>
                        <button><img src={Trash} /></button>                       
                    </div>
                ))}
            </div>
        </>
    )
}

