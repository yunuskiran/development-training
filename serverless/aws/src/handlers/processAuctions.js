import createError from "http-errors";
import { closeAuctions } from "../lib/closeAuctions";
import { getEndedAuctions } from "../lib/getEndedAuctions";

async function processAuctions(event, context) {
  try {
    const auctionsToClose = await getEndedAuctions();
    const closePromises = auctionsToClose.map((auctions) =>
      closeAuctions(auction)
    );
    await Promise.all(closePromises);

    return { closed: closePromises.length };
  } catch (error) {
    console.log(error);
    throw new createError.InternalServerError(error);
  }
}

export const handler = processAuctions;
