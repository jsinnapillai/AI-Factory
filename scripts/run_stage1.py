import os
import requests

API_KEY = os.getenv("OPENROUTER_API_KEY")

url = "https://openrouter.ai/api/v1/chat/completions"

with open("../prompts/stage1_prompt.txt","r",encoding="utf-8") as f:
    prompt = f.read()

headers = {
    "Authorization": f"Bearer {API_KEY}",
    "Content-Type": "application/json",
    "HTTP-Referer": "http://localhost",
    "X-Title": "AI-Factory"
}

data = {
    "model": "anthropic/claude-3.7-sonnet",
    "temperature": 0.25,
    "max_tokens": 35000,
    "messages": [
        {
            "role": "user",
            "content": prompt
        }
    ]
}

response = requests.post(url, headers=headers, json=data)

result = response.json()

with open("../output/stage1_output.txt","w",encoding="utf-8") as f:
    f.write(result["choices"][0]["message"]["content"])

print("Stage 1 generation complete.")