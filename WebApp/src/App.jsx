import { useState } from 'react'
import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router";

import ClientePage from './pages/Cliente/ClientePage';
import PagamentoPage from './pages/Pagamento/PagamentoPage';
import App from "./App";

const root = document.getElementById("root");
ReactDOM.createRoot(root).render(
    <BrowserRouter>
        <Routes path="/home">
            <Route index element={<ClientePage />} />
            <Route path="pagamento" element={<PagamentoPage />} />
        </Routes>
    </BrowserRouter>
);

export default App
