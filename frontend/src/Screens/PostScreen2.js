import React, {useState} from 'react'
import { useParams } from 'react-router-dom'
import { useEffect } from 'react'
import { useDispatch } from 'react-redux'
import { getRoomContext } from '../actions/forumActions'
import { useSelector } from 'react-redux'
import SingleAnwserComponent from '../Components/SingleAnwserComponent'
import Loader from '../Components/Loader'
import Message from '../Components/Message'
import { Button } from 'react-bootstrap'

export default function PostScreen2() {

    const {id} = useParams()
    const dispatch = useDispatch()

    const downMessage = useSelector(state => state.downMessage)
    const {error, loading, getRoominfo} = downMessage
    
    const [answers, setAnswers] = useState([])
    const [convertedAnswers, setConvertedAnswers] = useState([])

    const convertToObject = () =>{
        setConvertedAnswers(JSON.parse(answers))
    }

    // useEffect(() =>{
    //     dispatch(getRoomContext(id))
    //     setAnswers(localStorage.getItem('AnswersToPost'))
    //     setConvertedAnswers(JSON.parse(answers))
    //     console.log(typeof(convertedAnswers))
    //     console.log(convertedAnswers)
    // }, [dispatch, setConvertedAnswers, id, setAnswers])

    
    useEffect(() =>{
        dispatch(getRoomContext(id))
    }, [dispatch, id])
    

  return (
    <div>
        <div>
            <h1>{getRoominfo && getRoominfo.id}</h1>
            {/* {convertedAnswers.id} */}
            {/* {getRoominfo.id} */}
            {/* <SingleAnwserComponent data={getRoominfo} /> */}
            {/* {title} */}
            {/* {getRoominfo.id} */}
            {/* {loading ? <Loader /> : error ? <Message variant='danger'>{error}</Message> :
                <div>
                    <div style={{ width: '36rem' }}>
                        <Card.Body style={{ border:'3px solid black', margin: '20px'}}>
                            <Card.Title>Title: {getpost.title}</Card.Title>
                            <Card.Subtitle className="mb-2 text-muted">Author: {getpost["creator"].firstName}</Card.Subtitle>
                            <Card.Text>
                                Description: {getpost.description}
                            </Card.Text>
                        </Card.Body>
                        {getpost["postReplies"]?.map((item)=>{
                            return(
                                <div style={{ width: '36rem' , border:'1px solid black', margin: '10px'}}>
                                        <Card.Header>{item["user"].firstName} answer...</Card.Header>
                                        <ListGroup variant="flush">
                                        <ListGroup.Item>{item.message}</ListGroup.Item>
                                    </ListGroup>
                                </div>
                            )
                        })}
                        
                    </div>

                    <Form onSubmit={submitHandler}>
                        <Form.Group className="mb-3" controlId="exampleForm.ControlTextarea1">
                            <Form.Label>Your answer:</Form.Label>
                            <Form.Control as="textarea" rows={3} value={answer} onChange={(e) => setAnswer(e.target.value)}/>
                            <Button type="submit">Answer</Button>
                        </Form.Group>
                    </Form>
                </div>
            } */}
        </div>
    </div>
  )
}
