# Creating Custom Connector, and using it in Canvas App on 23-Oct-2021 at 04.45 PM IST



## Event URL: [https://www.linkedin.com/events/powerplatformclassmates6855192446750482432](https://www.linkedin.com/events/powerplatformclassmates6855192446750482432)

![Viswanatha Swamy P K |150x150](./documentation/images/ViswanathaSwamyPK.PNG)

---

## Information

![Information | 100x100](./documentation/images/Information.PNG)

## What are we doing today?

> 1. Viewing the existing Web API
> 1. Introduction to Custom Connector
> 1. Creating a Custom Connector from blank
> 1. Testing the Custom Connector
> 1. Creating Canvas App and using Custom Connector
> 1. SUMMARY / RECAP / Q&A


![Seat Belt | 100x100](./documentation/images/SeatBelt.PNG)

---

## 1. Viewing the existing Web API

> 1. Discussion
> 1. Accessing the API using Postman

URL: [https://conferenceapi.azurewebsites.net/](https://conferenceapi.azurewebsites.net/)

### Web API
![Web API | 100x100](./documentation/images/Simple_WebApi.PNG)

### Verifying Web API in Postman
![Verify API In Postman | 100x100](./documentation/images/Verify_API_In_Postman.PNG)

---

## 2. Introduction to Custom Connector
> 1. Discussion

URL: [https://docs.microsoft.com/en-us/connectors/custom-connectors](https://docs.microsoft.com/en-us/connectors/custom-connectors/)

---

## 3. Creating a Custom Connector from blank
> 1. Discussion

### Commands
```
curl --request GET --url https://conferenceapi.azurewebsites.net/speaker/1/sessions --header 'cache-control: no-cache' --header 'postman-token: 9cb2466c-a614-19ee-5151-b6f74f9afbff'

```

### Custom Connector using Blank
![Create New Custom Connector from blank | 100x100](./documentation/images/CreateNewCustomConnector.PNG)

---

## 4. Testing the Custom Connector
> 1. Discussion

![Testing Custom Connector with Custom Connector Creation Page | 100x100](./documentation/images/Testing_CustomConnector.PNG)

---

## 5. Creating Canvas App and using Custom Connector

> 1. Create Canvas App from Blank
> 1. Change the Layout
> 1. Add Data -> Speakers
> 1. Add TextBox, Two Galleries

```
SpeakerSessions.GetSpeakerSessions(TextInput1.Text).collection.items

If(ThisItem.IsSelected, RGBA(214, 223, 238, 1), RGBA(241, 244, 249, 1))

Gallery1.Selected.data

PlainText(ThisItem.value)
```

![Canvas App Image 1 | 100x100](./documentation/images/CanvasApp_1.PNG)
![Canvas App Image 2 | 100x100](./documentation/images/CanvasApp_2.PNG)
![Canvas App Image 3 | 100x100](./documentation/images/CanvasApp_3.PNG)
![Canvas App Image 4 | 100x100](./documentation/images/CanvasApp_4.PNG)
![Canvas App Image 5 | 100x100](./documentation/images/CanvasApp_5.PNG)
![Canvas App Image 6 | 100x100](./documentation/images/CanvasApp_6.PNG)
![Canvas App Image 7 | 100x100](./documentation/images/CanvasApp_7.PNG)

---

## 6. SUMMARY / RECAP / Q&A

---

> 1. SUMMARY / RECAP / Q&A
> 2. Any open queries, I will get back through meetup chat/twitter.

---


