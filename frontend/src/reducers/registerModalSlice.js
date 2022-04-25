import { createSlice } from '@reduxjs/toolkit'

const initialState = {
    value: false,
}

export const registerModalSlice = createSlice({
    name: 'registerModal',
    initialState,
    reducers: {
        setRegisterFalseValue: (state) =>{
            state.value = false
        },
        setRegisterTrueValue: (state) =>{
            state.value = true
        },
    },
})

export const { setRegisterFalseValue, setRegisterTrueValue } = registerModalSlice.actions
export default registerModalSlice.reducer