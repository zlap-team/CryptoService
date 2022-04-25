import React, {useState} from 'react'
import { Navbar, Container, Nav, Button } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'
import LoginModal from './LoginModal'
import App from '../App'
import { useSelector, useDispatch } from 'react-redux'
import { setFalseValue, setTrueValue } from '../reducers/modalSlice'

export default function Header() {
    const dispatch = useDispatch()

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

            <LinkContainer to='/dashboard'>
                <Navbar.Brand>
                    <Button>Dashboard</Button>
                </Navbar.Brand>
            </LinkContainer>

            <Navbar.Brand>
                <Button onClick={() => {
                    dispatch(setTrueValue())
                }} style={{position: 'absolute', right: '10px'}}>Login</Button>
            </Navbar.Brand>
            </Nav>
        </Container>
    </Navbar>
  )
}
