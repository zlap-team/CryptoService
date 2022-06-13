import React, {useState} from 'react'
import { Form, Button } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { useNavigate } from 'react-router-dom'
import { createPost } from '../actions/forumActions'

export default function NewRoomFormComponent() {

    const dispatch = useDispatch()
    const navigate = useNavigate()
    const [topic, setTopic] = useState('')
    const [description, setDescription] = useState('')

    const forumPost = useSelector(state => state.forumPost)
    const {error, loading, userInfo} = forumPost

    const submitHandler = (e) =>{
        e.preventDefault()
        dispatch(createPost(topic, description))
        navigate('/forum')
        window.location.reload();
    }

  return (
    <div>
        <Form onSubmit={submitHandler}>
            <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>Topic</Form.Label>
                <Form.Control type="text" placeholder="Enter your topic here!" value={topic} onChange={(e) => setTopic(e.target.value)} />
                <Form.Text className="text-muted">
                    Did you tried to google it first ? :DD
                </Form.Text>
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
                <Form.Label>Context</Form.Label>
                <Form.Control  as="textarea" rows={5} placeholder="Write your problem here!" value={description} onChange={(e) => setDescription(e.target.value)}/>
            </Form.Group>

            <Button variant="primary" type="submit">
                Post
            </Button>
        </Form>
    </div>
  )
}
