import React from 'react'
import { Navbar, Container, Nav, Button } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'
import App from '../App'

export default function Header() {

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

                <LinkContainer to='/login'>
                    <Navbar.Brand>
                        <Button>Login</Button>
                    </Navbar.Brand>
                </LinkContainer>

            </Nav>
        </Container>
    </Navbar>
  )
}
