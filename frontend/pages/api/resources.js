// Next.js API route support: https://nextjs.org/docs/api-routes/introduction

export default async function handler(req, res) {
  try {
    const twentyMinutesAgo = new Date(new Date().getTime() - 20 * 60 * 1000);
    let response = await fetch(`${process.env.API_URL}/statistics?startTime=${twentyMinutesAgo.toISOString()}`)
    const data = await response.json()
    res.status(200).json({response: data})
  } catch(e){
    res.status(500).json({error: e})
  }
}
