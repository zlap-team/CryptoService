// import React from 'react'
// import '../stylesheets/LoginModalCSS.css'
// import { Form, Button } from 'react-bootstrap'
// import { LinkContainer } from 'react-router-bootstrap'
// import { useDispatch } from 'react-redux'

// export default function LoginModal() {
//     const dispatch = useDispatch()

//   return (
//     <div className='modalBackground'>
//         <div className='modalContainer'>
//             <div className='title text-center'>
//             <Form>
//                 <Form.Group className="mb-3" controlId="formBasicEmail">
//                     <Form.Label>Email address</Form.Label>
//                     <Form.Control type="email" placeholder="Enter email" className='text-center'/>
//                 </Form.Group>

//                 <Form.Group className="mb-3" controlId="formBasicPassword">
//                     <Form.Label>Password</Form.Label>
//                     <Form.Control type="password" placeholder="Enter Password" className='text-center' />
//                 </Form.Group>
//                 <Button variant="primary" type="submit">
//                     Submit
//                 </Button>
//             </Form>
//             </div>
//             <div className='body'>
//                 <p className='mb-0'>Don't have account yet ?</p>
//                 <LinkContainer to ='/register/'>
//                     <Button variant="link" onClick={() => {dispatch(setFalseValue()); dispatch(setRegisterTrueValue())}}>Register</Button>
//                 </LinkContainer>
//             </div>
//             <div className='footer text-center'>
//                 <Button variant='danger' onClick={() => {dispatch(setFalseValue())}}>Cancel</Button>
//             </div>
//         </div>
//     </div>
//   )
// }
