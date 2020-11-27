import AWS from "aws-sdk";
import createError from "http-errors";
import middleware from "../lib/middleware";

const dynamodb = new AWS.DynamoDB.DocumentClient();

async function updateAuction(event, context) {
  let auction;
  const { id } = event.pathParameters;
  const { amount } = event.body;
  
  var params = {
    TableName: process.env.AUCTIONS_TABLE_NAME,
    Key: { id },
    UpdateExpression: "set amountGroup.amount= :amount",
    ExpressionAttributeValues: {
      ":amount": amount,
    },
    ReturnValues: "ALL_NEW",
  };

  try {
    const result = await dynamodb.update(params).promise();
    auction = result.Attributes;
    if (!auction) {
      throw new createError.NotFound(`Auction with Id "${id}" not found!`);
    }
  } catch (error) {
    console.log(error);
    throw new createError.InternalServerError(error);
  }

  return {
    statusCode: 200,
    body: JSON.stringify(auctions),
  };
}

export const handler = middleware(updateAuction);
