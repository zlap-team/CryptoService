import React, {useState, useEffect} from 'react'
import NewsComponent from '../Components/NewsComponent'
import { Row, Col } from 'react-bootstrap'
import axios from 'axios'

export default function NewsScreen() {

    const [news, setNews] = useState()

    useEffect(() =>{
        async function fetchNews(){
            const {data} = await axios.get('https://127.0.0.1:5001/api/NewsApi/crypto')
            setNews(data)
        }
        fetchNews()
    }, [])

  return (
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
  )
}
