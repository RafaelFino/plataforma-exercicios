from fastapi import FastAPI
from pydantic import BaseModel
from datetime import datetime

app = FastAPI(title="API Example", version="1.0.0")

class SumRequest(BaseModel):
    a: float
    b: float

@app.post("/sum")
def sum_post(payload: SumRequest):
    return {
        "timestamp": datetime.now().isoformat(),
        "result": payload.a + payload.b
    }