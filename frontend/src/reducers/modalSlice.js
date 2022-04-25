import { createSlice } from '@reduxjs/toolkit'

const initialState = {
    value: false,
}

export const modalSlice = createSlice({
    name: 'modal',
    initialState,
    reducers: {
        setFalseValue: (state) =>{
            state.value = false
        },
        setTrueValue: (state) =>{
            state.value = true
        },
    },
})

export const { setFalseValue, setTrueValue } = modalSlice.actions
export default modalSlice.reducer