# Project Requirements

## Sender

    Check CSV file exist or not
    Read CSV File
    write the word on console

## Reviver

    Create a CSV file
    Read the word from Console
    Check the word is already in the file or not
    IF the word is there increment the Word Count
    IF the word is not there enter the word in CSV 
    AND set the word count as 1

## Run

    Sender.exe | Reciver.exe
    Sender.exe --> write the data on Console
    Reciver.exe --> Read data from console

## Testing

    Test Sender independent of Reciver
    Test Reciver independent of Sender
    Test After integrating Sender and Reciver

## Extend Feature

    The Receiver removes stop words (words like a, the, and etc) 
    THAT do not contribute to our analysis
    When The input CSV contains the dates of the reviews
    Then  the Receiver can associate the word-counts with the date
