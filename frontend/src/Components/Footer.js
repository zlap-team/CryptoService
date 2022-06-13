import React from 'react'
import { Container, Row, Col } from 'react-bootstrap'

export default function Footer() {
  return (
    <div>
        <Container className='text-center'>
            <Row>
                <Col style={{paddingBottom: '5px'}}>Copyright &copy; BlockchainApp</Col>
            </Row>
        </Container>
    </div>
  )
}
