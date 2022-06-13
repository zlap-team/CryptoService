import { 
    ECONOMY_LIST_REQUEST,
    ECONOMY_LIST_SUCCESS,
    ECONOMY_LIST_FAIL,

    ECONOMY_DETAILS_REQUEST,
    ECONOMY_DETAILS_SUCCESS,
    ECONOMY_DETAILS_FAIL,

    NEWS_DETAILS_REQUEST,
    NEWS_DETAILS_SUCCESS,
    NEWS_DETAILS_FAIL,

    BANK_LIST_REQUEST,
    BANK_LIST_SUCCESS,
    BANK_LIST_FAIL,

    BANK_DETAILS_REQUEST,
    BANK_DETAILS_SUCCESS,
    BANK_DETAILS_FAIL,

    NEWS_LIST_REQUEST,
    NEWS_LIST_SUCCESS,
    NEWS_LIST_FAIL,

 } from "../constants/newsConstants";

export const newsListReducer = (state = {news:[]}, action) =>{
    switch(action.type){
        case NEWS_LIST_REQUEST:
            return {loading: true, news: []}
        
        case NEWS_LIST_SUCCESS:
            return {loading: false, news: action.payload}

        case NEWS_LIST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const newsDetailsReducer = (state = {news: {reviews: []}}, action) =>{
    switch(action.type){
        case NEWS_DETAILS_REQUEST:
            return {loading: true, ...state}

        case NEWS_DETAILS_SUCCESS:
            return {loading: false, product: action.payload}

        case NEWS_LIST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const bankListReducer = (state = {bank:[]}, action) =>{
    switch(action.type){
        case BANK_LIST_REQUEST:
            return {loading: true, bank: []}
        
        case BANK_LIST_SUCCESS:
            return {loading: false, bank: action.payload}

        case BANK_LIST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const bankDetailsReducer = (state = {bank: {reviews: []}}, action) =>{
    switch(action.type){
        case BANK_DETAILS_REQUEST:
            return {loading: true, ...state}

        case BANK_DETAILS_SUCCESS:
            return {loading: false, bank: action.payload}

        case BANK_LIST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const economyListReducer = (state = {economy:[]}, action) =>{
    switch(action.type){
        case ECONOMY_LIST_REQUEST:
            return {loading: true, economy: []}
        
        case ECONOMY_LIST_SUCCESS:
            return {loading: false, economy: action.payload}

        case ECONOMY_LIST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const economyDetailsReducer = (state = {economy: {reviews: []}}, action) =>{
    switch(action.type){
        case ECONOMY_DETAILS_REQUEST:
            return {loading: true, ...state}

        case ECONOMY_DETAILS_SUCCESS:
            return {loading: false, economy: action.payload}

        case ECONOMY_LIST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}