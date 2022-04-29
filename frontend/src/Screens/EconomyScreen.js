import React, {useState, useEffect} from 'react'
import NewsComponent from '../Components/NewsComponent'
import { Row, Col } from 'react-bootstrap'
import axios from 'axios'
import { listEconomyNews } from '../actions/newsActions'
import { useSelector, useDispatch } from 'react-redux'
import Loader from '../Components/Loader'
import Message from '../Components/Message'

export default function EconomyScreen() {

  // const [news, setNews] = useState()

  // useEffect(() =>{
  //     async function fetchNews(){
  //         const {data} = await axios.get('https://127.0.0.1:5001/api/NewsApi/economy')
  //         setNews(data)
  //     }
  //     fetchNews()
  // }, [])

  const dispatch = useDispatch()
  const economyList = useSelector(state => state.economyList)
  const {error, loading, economy} = economyList


  useEffect(() =>{
      dispatch(listEconomyNews())

  }, [dispatch])

  return (
    <div>
      {loading ? <Loader /> : error ? <Message variant='danger'>{error}</Message> :
      <Row>
            {economy?.map((item) => {
               return(
                <Col key={economy.title} sm={12} md={6} lg={3.5} xl={6}>
                    <NewsComponent news={item} />
                </Col>
               ) 
            })}
        </Row>
      }
    </div>
  )
}
