import { 
    ECONOMY_LIST_REQUEST,
    ECONOMY_LIST_SUCCESS,
    ECONOMY_LIST_FAIL,

    ECONOMY_DETAILS_REQUEST,
    ECONOMY_DETAILS_SUCCESS,
    ECONOMY_DETAILS_FAIL,

    BANK_LIST_REQUEST,
    BANK_LIST_SUCCESS,
    BANK_LIST_FAIL,

    BANK_DETAILS_REQUEST,
    BANK_DETAILS_SUCCESS,
    BANK_DETAILS_FAIL,

    NEWS_LIST_REQUEST,
    NEWS_LIST_SUCCESS,
    NEWS_LIST_FAIL,

    NEWS_DETAILS_REQUEST,
    NEWS_DETAILS_SUCCESS,
    NEWS_DETAILS_FAIL
 } from "../constants/newsConstants";
import axios from 'axios'


export const listBankNews = () => async (dispatch) =>{
    try{
        dispatch({type: BANK_LIST_REQUEST})
        const { data } = await axios.get('https://127.0.0.1:5001/api/NewsApi/bank')

        dispatch({
            type: BANK_LIST_SUCCESS,
            payload: data
        })
    }
    catch(error){
        dispatch({
            type: NEWS_LIST_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}

export const listEconomyNews = () => async (dispatch) =>{
    try{
        dispatch({type: ECONOMY_LIST_REQUEST})
        const { data } = await axios.get('https://127.0.0.1:5001/api/NewsApi/economy')

        dispatch({
            type: ECONOMY_LIST_SUCCESS,
            payload: data
        })
    }
    catch(error){
        dispatch({
            type: ECONOMY_LIST_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}

export const listCryptoNews = () => async (dispatch) =>{
    try{
        dispatch({type: NEWS_LIST_REQUEST})
        const { data } = await axios.get('https://127.0.0.1:5001/api/NewsApi/crypto')

        dispatch({
            type: NEWS_LIST_SUCCESS,
            payload: data
        })
    }
    catch(error){
        dispatch({
            type: NEWS_LIST_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}