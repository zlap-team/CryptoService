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
                <Navbar.Brand><h2>Business and Crypto</h2></Navbar.Brand>
            </LinkContainer>
            <Nav className="me-auto">

                <LinkContainer to='/'>
                    <Navbar.Brand>
                        <Button><h5>Home</h5></Button>
                    </Navbar.Brand>
                </LinkContainer>

                <LinkContainer to='/news'>
                    <Navbar.Brand>
                        <Button><h5>News</h5></Button>
                    </Navbar.Brand>
                </LinkContainer>

                <LinkContainer to='/bank'>
                    <Navbar.Brand>
                        <Button><h5>Bank</h5></Button>
                    </Navbar.Brand>
                </LinkContainer>

                <LinkContainer to='/economy'>
                    <Navbar.Brand>
                        <Button><h5>Economy</h5></Button>
                    </Navbar.Brand>
                </LinkContainer>

                {/* <LinkContainer to='/forum'>
                    <Navbar.Brand>
                        <Button>Forum</Button>
                    </Navbar.Brand>
                </LinkContainer> */}

                {userInfo ?(
                        <LinkContainer to='/forum'>
                            <Navbar.Brand>
                                <Button><h5>Forum</h5></Button>
                            </Navbar.Brand>
                        </LinkContainer>
                ):(
                        <LinkContainer to="/loginForum">
                            <Button style={{padding: 0}}><h5>Forum</h5><AiOutlineQuestionCircle/></Button>  
                        </LinkContainer>

                )}
                

                {userInfo ? (
                        <NavDropdown title={<h5>{userInfo.firstName}</h5>} id='username'>

                            <NavDropdown.Item onClick={logoutHandler}><h5>Wyloguj</h5></NavDropdown.Item>
                            
                        </NavDropdown>

                        
                    ) :(
                            <LinkContainer to='/login'>
                                <Nav.Link><Button variant='success' style={{margin: 0}} >Zaloguj</Button></Nav.Link>
                            </LinkContainer>
                    )}

            </Nav>
        </Container>
    </Navbar>
  )
}
