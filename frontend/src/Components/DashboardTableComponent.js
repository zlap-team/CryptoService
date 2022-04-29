import React from 'react'
import Image from 'react-bootstrap/Image'

export default function DashboardTableComponent({coinsData}) {

    const myDate = new Date(coinsData.lastUpdated)
    const timeNow = Date.now()
    Date.parse(myDate)
    const timeDifference = timeNow - myDate

    function dhm (ms) {
        const days = Math.floor(ms / (24*60*60*1000));
        const daysms = ms % (24*60*60*1000);
        const hours = Math.floor(daysms / (60*60*1000));
        const hoursms = ms % (60*60*1000);
        const minutes = Math.floor(hoursms / (60*1000));
        const minutesms = ms % (60*1000);
        const sec = Math.floor(minutesms / 1000);

        if (days > 0){
            return days + " days ago"
        }else if (days <= 0 && minutes >= 60){
            return hours + " hours ago"
        }else if(hours < 1 && sec >= 60){
            return minutes + " minutes ago"
        }else{
            return sec + " seconds ago"
        }
    }
    
  return (
        <tr>
            <td><Image src={coinsData.image} width={'40vw'}></Image></td>
            <td><h5 className='text-secondary'>{coinsData.name}</h5></td>
            <td><h5>{coinsData.currentPrice}</h5></td>
            {coinsData.priceChange24h>0 ? <td><h5 className='text-success'>{coinsData.priceChange24h}</h5></td> : <h5 className='text-danger'>{coinsData.priceChange24h}</h5>}
            <td><h6>{dhm(timeDifference)}</h6></td>
        </tr>
  )
}
