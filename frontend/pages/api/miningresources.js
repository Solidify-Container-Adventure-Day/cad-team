// Next.js API route support: https://nextjs.org/docs/api-routes/introduction

export default async function handler(req, res) {
  try {
    let response = await fetch(`${process.env.API_URL}/resources/quantity`)
    const data = await response.json()
    res.status(200).json(data)
  } catch(e){
    res.status(500).json({error: e})
  }
}
