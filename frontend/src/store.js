import { applyMiddleware, combineReducers } from '@reduxjs/toolkit'
import { legacy_createStore } from 'redux'
import thunk from 'redux-thunk'
import { composeWithDevTools } from 'redux-devtools-extension'
import { userLoginReducer, userRegisterReducer } from './reducers/userReducer'
import { cryptoListReducer, getSingleCryptoReducer } from './reducers/cryptoReducer'
import { newsListReducer, economyListReducer, bankListReducer } from './reducers/newsReducers'
import { createPostReducer, getPostsReducer, getRoomContextReducer, getSinglePostReducer, putMessageReducer } from './reducers/forumReducers'

const reducer = combineReducers({
    userLogin: userLoginReducer,
    userRegister: userRegisterReducer,
    cryptoList: cryptoListReducer,
    newsList: newsListReducer,
    bankList: bankListReducer,
    economyList: economyListReducer,
    forumPost: createPostReducer,
    forumGetPost: getPostsReducer,
    forumGetSinglePost: getSinglePostReducer,
    getSingleCrypro: getSingleCryptoReducer,
    putMessage: putMessageReducer,
    downMessage: getRoomContextReducer,
})

const userInfoFromStorage = localStorage.getItem('userInfo') ? JSON.parse(localStorage.getItem('userInfo')) : null

const initialState={
    userLogin: {userInfo: userInfoFromStorage}
}

const middleware = [thunk]

const store = legacy_createStore(reducer, initialState, composeWithDevTools(applyMiddleware(...middleware)))

export default store