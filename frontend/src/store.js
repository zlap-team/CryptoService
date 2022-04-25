import { configureStore } from '@reduxjs/toolkit'
import modalReducer from './reducers/modalSlice'
import registerModalReducer from './reducers/registerModalSlice'
export const store = configureStore({
    reducer: {
        modal: modalReducer,
        registerModal: registerModalReducer
    },
})