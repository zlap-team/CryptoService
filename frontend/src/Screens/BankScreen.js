import React, {useState, useEffect} from 'react'
import NewsComponent from '../Components/NewsComponent'
import { Row, Col } from 'react-bootstrap'
import axios from 'axios'
import { listBankNews } from '../actions/newsActions'
import { useDispatch, useSelector } from 'react-redux'
import Loader from '../Components/Loader'
import Message from '../Components/Message'

export default function BankScreen() {

    // const [news, setNews] = useState()

    // useEffect(() =>{
    //     async function fetchNews(){
    //         const {data} = await axios.get('https://127.0.0.1:5001/api/NewsApi/bank')
    //         setNews(data)
    //     }
    //     fetchNews()
    // }, [])

    const dispatch = useDispatch()
    const bankList = useSelector(state => state.bankList)
    const {error, loading, bank} = bankList


    useEffect(() =>{
        dispatch(listBankNews())

    }, [dispatch])

  return (
    <div>
        {loading ? <Loader /> : error ? <Message variant='danger'>{error}</Message> :
            <Row>
                {bank?.map((item) => {
                return(
                    <Col key={bank.title} sm={12} md={6} lg={3.5} xl={6}>
                        <NewsComponent news={item} />
                    </Col>
                ) 
                })}
            </Row>
        }
    </div>
  )
}
