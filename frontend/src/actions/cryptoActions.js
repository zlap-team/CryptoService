import { CRYPTO_LIST_REQUEST, CRYPTO_LIST_SUCCESS, CRYPTO_LIST_FAIL } from "../constants/cryptoConstants";
import axios from 'axios'

export const listCrypto = () => async (dispatch) =>{
    try{
        dispatch({type: CRYPTO_LIST_REQUEST})
        const { data } = await axios.get('https://127.0.0.1:5001/api/CoinGeckoApi/markets/dot')

        dispatch({
            type: CRYPTO_LIST_SUCCESS,
            payload: data
        })
    }
    catch(error){
        dispatch({
            type: CRYPTO_LIST_FAIL,
            payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
        })
    }
}

// export const listProductDetails = (id) => async (dispatch) => {
//     try{
//         dispatch({type: PRODUCT_DETAILS_REQUEST})
//         const { data } = await axios.get(`http://127.0.0.1:8000/products/${id}`)

//         dispatch({
//             type: PRODUCT_DETAILS_SUCCESS,
//             payload: data
//         })
//     }
//     catch(error){
//         dispatch({
//             type: PRODUCT_DETAILS_FAIL,
//             payload: error.response && error.response.data.detail ? error.response.data.detail : error.message
//         })
//     }
// }