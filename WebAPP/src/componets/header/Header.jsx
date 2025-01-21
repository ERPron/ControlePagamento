import './Header.css'
import Trash from '../../assets/react.svg'
function Header() {
    return (
        <div className="menu">
            <nav class="navbar  border-bottom border-body" data-bs-theme="dark">
                <div class="container">
                    <ul className="menu">                      
                        <li><img src={Trash}/></li>
                        <li> <a href="/">Cliente</a> </li>
                        <li> <a href="/Pagamento">Pagamento</a> </li>
                    </ul>
                </div>
            </nav>
        </div>
    )
}

export default Header