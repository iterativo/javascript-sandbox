require File.dirname(__FILE__) + '/tournament.rb'
require 'test/unit'

class TournamentTests < Test::Unit::TestCase
  
  def test_should_determine_the_winner_of_a_single_level_tournament
    match = [ 
      ["Ronald", 2], ["Frank", 3] 
    ]
    tournament = Tournament.new
    winner = tournament.play(match)
    assert_equal("Frank", winner[0])
  end
  
  def test_should_determine_the_winner_of_a_double_level_tournament
    matches = [ 
      [ 
        ["Ronald", 2], ["Frank", 3] 
      ],
      [ 
        ["Martha", 4], ["Adele", 5] 
      ]
    ]
    tournament = Tournament.new
    winner = tournament.play(matches)
    assert_equal("Adele", winner[0])
  end
  
  def test_should_determine_the_winner_of_a_triple_level_tournament
    matches = [ 
      [ 
        [ 
          ["Ronald", 2], ["Frank", 3] 
        ],  
        [ 
          ["Martha", 4], ["Adele", 5] 
        ]
      ],
      [ 
        [ 
          ["Carl", 10], ["Joseph", 1] 
        ],
        [  
          ["Nancy", 7], ["Rico", 8] 
        ] 
      ]
    ]
    tournament = Tournament.new
    winner = tournament.play(matches)
    assert_equal("Carl", winner[0])
  end
  
end
