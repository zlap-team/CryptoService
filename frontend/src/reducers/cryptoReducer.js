import { CRYPTO_LIST_SUCCESS, CRYPTO_LIST_REQUEST, CRYPTO_LIST_FAIL, CRYPTO_DETAILS_REQUEST, CRYPTO_DETAILS_SUCCESS, 
         GET_SINGLE_CRYPTO_REQUEST, GET_SINGLE_CRYPTO_SUCCESS, GET_SINGLE_CRYPTO_FAIL
} from "../constants/cryptoConstants"

export const cryptoListReducer = (state = {products:[]}, action) =>{
    switch(action.type){
        case CRYPTO_LIST_REQUEST:
            return {loading: true, products: []}
        
        case CRYPTO_LIST_SUCCESS:
            return {loading: false, products: action.payload}

        case CRYPTO_LIST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const cryptoDetailsReducer = (state = {product: {reviews: []}}, action) =>{
    switch(action.type){
        case CRYPTO_DETAILS_REQUEST:
            return {loading: true, ...state}

        case CRYPTO_DETAILS_SUCCESS:
            return {loading: false, product: action.payload}

        case CRYPTO_LIST_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}

export const getSingleCryptoReducer = (state = {singleCrypto: {reviews: []}}, action) =>{
    switch(action.type){
        case GET_SINGLE_CRYPTO_REQUEST:
            return {loading: true, ...state}

        case GET_SINGLE_CRYPTO_SUCCESS:
            return {loading: false, singleCrypto: action.payload}

        case GET_SINGLE_CRYPTO_FAIL:
            return {loading: false, error: action.payload}

        default:
            return state
    }
}
