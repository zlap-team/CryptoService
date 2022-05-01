import { CREATE_POST_REQUEST, CREATE_POST_SUCCESS, CREATE_POST_FAIL,
         GET_POSTS_REQUEST, GET_POSTS_SUCCESS, GET_POSTS_FAIL,
         GET_POST_REQUEST, GET_POST_SUCCESS, GET_POST_FAIL,
         PUT_MESSAGE_REQUEST, PUT_MESSAGE_SUCCESS, PUT_MESSAGE_FAIL,
         GET_ROOM_MESSAGES_REQUEST, GET_ROOM_MESSAGES_SUCCESS, GET_ROOM_MESSAGES_FAIL,
} from "../constants/forumConstants"

export const createPostReducer = (state = {}, action) =>{
    switch(action.type){
        case CREATE_POST_REQUEST:
            return {loading: true, posts: []}
        
        case CREATE_POST_SUCCESS:
            return {loading: false, userInfo: action.payload}

        case CREATE_POST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const getPostsReducer = (state = {}, action) =>{
    switch(action.type){
        case GET_POSTS_REQUEST:
            return {loading: true, getposts: []}
        
        case GET_POSTS_SUCCESS:
            return {loading: false, getposts: action.payload}

        case GET_POSTS_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const getSinglePostReducer = (state = {}, action) =>{
    switch(action.type){
        case GET_POST_REQUEST:
            return {loading: true, getpost: []}
        
        case GET_POST_SUCCESS:
            return {loading: false, getpost: action.payload}

        case GET_POST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const putMessageReducer = (state = {}, action) =>{
    switch(action.type){
        case PUT_MESSAGE_REQUEST:
            return {loading: true, message: []}
        
        case PUT_MESSAGE_SUCCESS:
            return {loading: false, userInfo: action.payload}

        case PUT_MESSAGE_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const getRoomContextReducer = (state = {}, action) =>{
    switch(action.type){
        case 'GET_ROOM_MESSAGES1_REQUEST':
            return {loading: true, getRoominfo: []}
        
        case GET_ROOM_MESSAGES_SUCCESS:
            return {loading: false, getRoominfo: action.payload}

        case GET_ROOM_MESSAGES_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}