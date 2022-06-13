import React, {useEffect, useState} from 'react'
import { getSinglePost } from '../actions/forumActions'
import { useDispatch, useSelector } from 'react-redux'
import Loader from '../Components/Loader'
import Message from '../Components/Message'
import { useParams } from 'react-router-dom'
import { Card, Button } from 'react-bootstrap'
import { Form } from 'react-bootstrap'
import { putMessage } from '../actions/forumActions'
import { getRoomContext } from '../actions/forumActions'
import { ListGroup } from 'react-bootstrap'

export default function PostScreen() {

    const dispatch = useDispatch()
    const {id} = useParams()
    const [answer, setAnswer] = useState('')

    const forumGetSinglePost = useSelector(state => state.forumGetSinglePost)
    const {error, loading, getpost} = forumGetSinglePost
    
    // const putMessage = useSelector(state => state.putMessage)
    // const {error, loading, getpost} = putMessage

    // const Myfunction = () =>{
    //     const getRoomMessagess = useSelector(state => state.getRoomMessagess)
    //     // const {error, loading, getRoomMessages} = getRoomMessagess
    //     const zmienna = getRoomMessages
    // }
    // Myfunction()

    const downMessage = useSelector(state => state.downMessage)
    // const {error, loading, getRoominfo} = downMessage


    const submitHandler = (e) =>{
        e.preventDefault()
        dispatch(putMessage(answer))
    }


    useEffect(() =>{
        // dispatch(getRoomContext(id))
        dispatch(getSinglePost(id))
        console.log(getpost)
    }, [dispatch, id])
    
    const refreshPage = ()=>{
        window.location.reload();
        // dispatch(getSinglePost(id))
     }



     function dhm (ms) {
        const myDate = new Date(ms)
        const timeNow = Date.now()
        const parsedData = Date.parse(myDate)
        const timeDifference = timeNow - parsedData

        const days = Math.floor(timeDifference / (24*60*60*1000));
        const daysms = timeDifference % (24*60*60*1000);
        const hours = Math.floor(daysms / (60*60*1000));
        const hoursms = timeDifference % (60*60*1000);
        const minutes = Math.floor(hoursms / (60*1000));
        const minutesms = timeDifference % (60*1000);
        const sec = Math.floor(minutesms / 1000);
        console.log(minutes)

        if (days > 0){
            return days + " days ago"
        }else if (days < 1 && minutes >= 60){
            return hours + " hours ago"
        }else if(hours < 1){
            return minutes + " minutes ago"
        }else if(minutes < 1){
            return sec + " seconds ago"
        }

        
        
    }

  return (
    <div>
        {loading ? <Loader /> : error ? <Message variant='danger'>{error}</Message> :
            <div>
                <div style={{ width: '36rem' }}>
                    <Card.Body style={{ border:'3px solid black', margin: '20px'}}>
                        <Card.Title>Title: {getpost && getpost.title}</Card.Title>
                        <Card.Subtitle className="mb-2 text-muted">Author: {getpost && getpost["creator"].firstName}</Card.Subtitle>
                        <Card.Text>
                            Description: {getpost && getpost.description}
                        </Card.Text>
                    </Card.Body>
                    {getpost && getpost["postReplies"]?.map((item)=>{
                        return(
                            <div style={{ width: '36rem' , border:'1px solid black', margin: '10px'}}>
                                    <Card.Header>{item["user"].firstName} answer...<h6 style={{float: 'right'}}>time {dhm(item.createdAt)}</h6></Card.Header>
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
                        <Button type="submit" onClick={refreshPage} >Answer</Button>
                    </Form.Group>
                </Form>
            </div>
        }
    </div>
  )
}
