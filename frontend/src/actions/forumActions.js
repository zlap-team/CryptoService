import axios from 'axios'
import { CREATE_POST_REQUEST, CREATE_POST_SUCCESS, CREATE_POST_FAIL,
         GET_POSTS_REQUEST, GET_POSTS_SUCCESS, GET_POSTS_FAIL,
         GET_POST_REQUEST, GET_POST_SUCCESS, GET_POST_FAIL,
         PUT_MESSAGE_REQUEST, PUT_MESSAGE_SUCCESS, PUT_MESSAGE_FAIL,
         GET_ROOM_MESSAGES_REQUEST, GET_ROOM_MESSAGES_SUCCESS, GET_ROOM_MESSAGES_FAIL
} from "../constants/forumConstants"

export const createPost = (title, description) => async (dispatch, getState) =>{
    try{
        dispatch({
            type: CREATE_POST_REQUEST
        })

        const {userLogin: {userInfo}, } = getState()

        const config = {
            headers: {
                'Content-type': 'application/json'
            }
        }

        const {data} = await axios.post('https://localhost:5001/api/Forum/create-post', {'title': title, 'description': description, 'creatorId': userInfo.id}, config)

        dispatch({
            type: CREATE_POST_SUCCESS,
            payload: data
        })

    }catch(error){
        dispatch({
            type: CREATE_POST_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}

export const getPosts = () => async (dispatch) =>{
    try{
        dispatch({type: GET_POSTS_REQUEST})
        const { data } = await axios.get('https://localhost:5001/api/Forum/posts')

        dispatch({
            type: GET_POSTS_SUCCESS,
            payload: data
        })
    }
    catch(error){
        dispatch({
            type: GET_POSTS_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}

export const getSinglePost = (id) => async (dispatch) =>{
    try{
        dispatch({type: GET_POST_REQUEST})
        const { data } = await axios.get('https://localhost:5001/api/Forum/posts')
        
        var singlePost = []
        data?.map((item)=>{
            if(item.id === id){
                singlePost = item
            }
            
        })
        // console.log(singlePost)

        dispatch({
            type: GET_POST_SUCCESS,
            payload: singlePost
        })
    }
    catch(error){
        dispatch({
            type: GET_POST_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}

export const putMessage = (message) => async (dispatch, getState) =>{
    try{
        dispatch({
            type: PUT_MESSAGE_REQUEST
        })

        const {userLogin: {userInfo}, } = getState()
        const {forumGetSinglePost: {getpost}, } = getState()

        const config = {
            headers: {
                'Content-type': 'application/json'
            }
        }

        const {data} = await axios.put(`https://localhost:5001/api/Forum/${getpost.id}/add-reply`, {'message': message, 'userId': userInfo.id}, config)

        dispatch({
            type: PUT_MESSAGE_SUCCESS,
            payload: data
        })

    }catch(error){
        dispatch({
            type: PUT_MESSAGE_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}

export const getRoomContext = (id) => async (dispatch) =>{
    try{
        dispatch({type: 'GET_ROOM_MESSAGES1_REQUEST'})
        const { data } = await axios.get(`https://localhost:5001/api/Forum/posts/${id}`)

        // var singlePost = []
        // data?.map((item)=>{
        //     if(item.id === id){
        //         singlePost = item
        //     }
            
        // })

        dispatch({
            type: GET_ROOM_MESSAGES_SUCCESS,
            payload: data
        })
        localStorage.setItem('AnswersToPost', JSON.stringify(data))
    }
    catch(error){
        dispatch({
            type: GET_ROOM_MESSAGES_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}