import React, {useState} from 'react'
import { Navbar, Container, Nav, Button } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'
import App from '../App'
import { useSelector } from 'react-redux'
import { useDispatch } from 'react-redux'
import { NavDropdown } from 'react-bootstrap'
import { logout } from '../actions/userActions'
import { AiOutlineUser } from 'react-icons/ai'
import { AiOutlineQuestionCircle } from 'react-icons/ai'
import { Tooltip } from 'bootstrap'

export default function Header() {

    const userLogin = useSelector(state => state.userLogin)
    const {userInfo} = userLogin


    const dispatch = useDispatch()

    const logoutHandler = () =>{
        dispatch(logout())
    }

  return (
    <Navbar bg="primary" variant="dark">
        <Container>

            <LinkContainer to='/'>
                <Navbar.Brand>BlockchainApp</Navbar.Brand>
            </LinkContainer>
            <Nav className="me-auto">

                <LinkContainer to='/'>
                    <Navbar.Brand>
                        <Button>Home</Button>
                    </Navbar.Brand>
                </LinkContainer>

                <LinkContainer to='/news'>
                    <Navbar.Brand>
                        <Button>News</Button>
                    </Navbar.Brand>
                </LinkContainer>

                <LinkContainer to='/bank'>
                    <Navbar.Brand>
                        <Button>Bank</Button>
                    </Navbar.Brand>
                </LinkContainer>

                <LinkContainer to='/economy'>
                    <Navbar.Brand>
                        <Button>Economy</Button>
                    </Navbar.Brand>
                </LinkContainer>

                {userInfo ?(
                        <LinkContainer to='/dashboard'>
                            <Navbar.Brand>
                                <Button>Dashboard</Button>
                            </Navbar.Brand>
                        </LinkContainer>
                ):(
                        <LinkContainer to="/loginDashboard">
                            <Button>Dashboard <AiOutlineQuestionCircle/></Button>  
                        </LinkContainer>
                )}
                

                {userInfo ? (
                        <NavDropdown title={userInfo.firstName} id='username'>
                            <LinkContainer to='/profile'>
                                <NavDropdown.Item>Profil</NavDropdown.Item>
                            </LinkContainer>

                            <NavDropdown.Item onClick={logoutHandler}>Wyloguj</NavDropdown.Item>
                            
                        </NavDropdown>

                        
                    ) :(
                            <LinkContainer to='/login'>
                                <Nav.Link>Zaloguj <AiOutlineUser /></Nav.Link>
                            </LinkContainer>
                    )}

            </Nav>
        </Container>
    </Navbar>
  )
}
