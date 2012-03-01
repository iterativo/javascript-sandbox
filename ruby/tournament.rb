class Tournament

  def play(matches)
    set1, set2 = matches[0], matches[1]
    if(is_a_match?(matches))
      return who_wins?(set1, set2)
    else
      set1_winner = play set1
      set2_winner = play set2
      play [set1_winner, set2_winner]
    end
  end
  
  private
  
  def who_wins?(player1, player2)
    return player1[1] >= player2[1] ? player1 : player2
  end
  
  def is_a_match?(set)
    return set[0][0].kind_of?(String)
  end
  
end
