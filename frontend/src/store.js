import { applyMiddleware, combineReducers } from '@reduxjs/toolkit'
import { legacy_createStore } from 'redux'
import thunk from 'redux-thunk'
import { composeWithDevTools } from 'redux-devtools-extension'
import { userLoginReducer, userRegisterReducer } from './reducers/userReducer'
import { cryptoListReducer } from './reducers/cryptoReducer'
import { newsListReducer, economyListReducer, bankListReducer } from './reducers/newsReducers'

const reducer = combineReducers({
    userLogin: userLoginReducer,
    userRegister: userRegisterReducer,
    cryptoList: cryptoListReducer,
    newsList: newsListReducer,
    bankList: bankListReducer,
    economyList: economyListReducer
})

const userInfoFromStorage = localStorage.getItem('userInfo') ? JSON.parse(localStorage.getItem('userInfo')) : null

const initialState={
    userLogin: {userInfo: userInfoFromStorage}
}

const middleware = [thunk]

const store = legacy_createStore(reducer, initialState, composeWithDevTools(applyMiddleware(...middleware)))

export default store