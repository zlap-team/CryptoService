import React, {useEffect, useState} from 'react'
import RoomComponent from '../Components/RoomComponent'
import { Button } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'
import { getPosts } from '../actions/forumActions'
import { useDispatch, useSelector } from 'react-redux'
import Loader from '../Components/Loader'
import Message from '../Components/Message'

export default function ForumScreen() {

    const dispatch = useDispatch()
    const forumGetPost = useSelector(state => state.forumGetPost)
    const {error, loading, getposts} = forumGetPost

    useEffect(() =>{
        dispatch(getPosts())
        console.log(getposts)
    }, [dispatch])

  return (
    <div>
        <h1>Welcome on our discussion forum</h1>
        
        <LinkContainer to='/create_new_post'>
            <Button>Create new Room</Button>
        </LinkContainer >
        
        {loading ? <Loader /> : error ? <Message variant='danger'>{error}</Message> :
            <div>
                {getposts?.map((post)=>{
                    return(
                        <RoomComponent key={post.id} posts={post} />
                    )
                })}
            </div>
        }
        
    </div>
  )
}
