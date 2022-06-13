import React from 'react'
import { Card, Button } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'

export default function RoomComponent({posts}) {

    const cutDescription = (text) =>{
        if (text.length >= 50){
            return text.slice(0, 50) + "..."
        }else{
            return text.slice(0, 50)
        }
    }

    
  return (
    <Card className='m-4'>
        <Card.Header>Posted by {posts.creator.firstName}</Card.Header>
        <Card.Body>
            <Card.Title>{posts.title}</Card.Title>
            <Card.Text>
                {cutDescription(posts.description)}
            </Card.Text>
            <LinkContainer to={`/post/${posts.id}`}>
                <Button variant="primary">Go to Post</Button>
            </LinkContainer>
            
        </Card.Body>
    </Card>
  )
}
