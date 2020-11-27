import { v4 as uuid, v4 } from "uuid";
import AWS from "aws-sdk";
import middleware from "../lib/middleware";
import validator from "@middy/validator";
import createError from "http-errors";
import createAuctionSchema from "../lib/schemas/createAuctionSchema";

const dynamodb = new AWS.DynamoDB.DocumentClient();

async function createAuction(event, context) {
  const { title } = event.body;
  var now = new Date();
  var endDate = new Date();
  endDate.setHours(now.getHours() + 1);

  const auction = {
    id: uuid(),
    title,
    status: "OPEN",
    createdAt: now.toISOString(),
    endingAt: endDate.toISOString(),
    amountGroup: {
      amount: 0,
    },
  };

  try {
    await dynamodb
      .put({
        TableName: process.env.AUCTIONS_TABLE_NAME,
        Item: auction,
      })
      .promise();
  } catch (errror) {
    console.log(error);
    throw new createError.InternalServerError(error);
  }

  return {
    statusCode: 201,
    body: JSON.stringify(auction),
  };
}

export const handler = middleware(createAuction).use(
  validator({ inputSchema: createAuction })
);
