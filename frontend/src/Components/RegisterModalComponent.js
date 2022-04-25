import React from 'react'
import '../stylesheets/LoginModalCSS.css'
import { Form, Button } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'
import { useDispatch } from 'react-redux'
import { setRegisterFalseValue } from '../reducers/registerModalSlice'
import { setFalseValue, setTrueValue } from '../reducers/modalSlice'

export default function LoginModal() {
    const dispatch = useDispatch()

  return (
    <div className='modalBackground'>
        <div className='RegisterModalContainer'>
            <div className='title text-center'>
            <Form>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Email address</Form.Label>
                    <Form.Control type="email" placeholder="Enter email" className='text-center'/>
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control type="password" placeholder="Enter Password" className='text-center' />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Confirm Password</Form.Label>
                    <Form.Control type="password" placeholder="Enter Password" className='text-center' />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>First Name</Form.Label>
                    <Form.Control type="text" placeholder="Enter Password" className='text-center' />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Last Name</Form.Label>
                    <Form.Control type="text" placeholder="Enter Password" className='text-center' />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
                <Button variant="primary" type="submit" onClick={() => {dispatch(setTrueValue()); dispatch(setRegisterFalseValue())}}>
                    Back
                </Button>
            </Form>
            </div>
            <div className='footer text-center' style={{position: 'relative', bottom: -40}}>
                <Button variant="link" onClick={() => {dispatch(setFalseValue()); dispatch(setRegisterFalseValue())}}>Continue without registering</Button>
            </div>
        </div>
    </div>
  )
}
