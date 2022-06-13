import React, {useState, useEffect} from 'react'
import NewsComponent from '../Components/NewsComponent'
import { Row, Col } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { listCryptoNews } from '../actions/newsActions'
import Loader from '../Components/Loader'
import Message from '../Components/Message'

export default function NewsScreen() {

    const dispatch = useDispatch()
    const newsList = useSelector(state => state.newsList)
    const {error, loading, news} = newsList


    useEffect(() =>{
        dispatch(listCryptoNews())

    }, [dispatch])

  return (
    <div>
        {loading ? <Loader /> : error ? <Message variant='danger'>{error}</Message> : 
        <div>
            <Row>
                {news?.map((item) => {
                return(
                    <Col key={news.title} sm={12} md={6} lg={3.5} xl={6}>
                        <NewsComponent news={item} />
                    </Col>
                ) 
                })}
            </Row>
        </div>
    }
    </div>
  )
}
