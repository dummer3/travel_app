import requests
import json

def APIrequest():
    #gets all the data from the National Transport API
    #if jsonFile is specified, stores the result in the specified json file
    url = "https://api.nationaltransport.ie/gtfsr/v2/gtfsr?format=json"
    hdr ={# Request headers
          'Cache-Control': 'no-cache',
          'x-api-key': '0f564cc3440841d9a6433fd3a109c4d0',}


    response = requests.get(url, headers=hdr, verify=True)

    #print(response.status_code)

    if response.status_code == 429:     #means the API has been called too many times, will use the last stored API answer
        answer = False
    else:                               #should have worked, will use live data and store it in a json file
        answer = json.loads(response.content)

    return answer
APIrequest()