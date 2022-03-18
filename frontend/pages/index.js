import { useEffect, useState } from 'react'
import { Line } from 'react-chartjs-2';
import {
  Chart,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement
} from 'chart.js';
Chart.register(CategoryScale, LinearScale, PointElement, LineElement);

export default function Home() {
  const [resources, setResources] = useState(null)
  useEffect(() => {
    const interval = setInterval(() => {
      getResources();
    }, 120000);
    return () => {
      clearInterval(interval)
    }
  }, [])
  const getResources = async () => {
    let response = await fetch(`api/resources`)
    const data = await response.json()
    console.log(data)
    setResources(data.response)
  }

  return (
    <div className="App">
      <header className="App-header">
        <div style={{ width: '70%' }}>
          <Line data={{
            datasets: [{
              data: resources,
              backgroundColor: 'rgba(255, 99, 132, 0.2)',
              borderColor: 'red',
            }]
          }}
            options={{
              parsing: {
                xAxisKey: 'time',
                yAxisKey: 'quantity',
              }, scales: {
                y: {
                  min: 0,
                  max: 20
                }
              }
            }} />
        </div>
        <button onClick={getResources}>
          UPDATE
        </button>
      </header>
    </div>
  )
}
